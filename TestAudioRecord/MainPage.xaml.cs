using Plugin.Maui.Audio;
using TestAudioRecord.DataBaseFolder;

namespace TestAudioRecord
{
    public partial class MainPage : ContentPage
    {
        private DataBase DB { get; set; }
        private readonly IAudioManager _audioManager;
        readonly IAudioRecorder _audioRecorder;
        private byte[] audioFile;
        public MainPage(IAudioManager audioManager, DataBase db)
        {
            InitializeComponent();

            _audioManager = audioManager;
            _audioRecorder = _audioManager.CreateRecorder();
            DB = db;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
                List<VoiceMessage> vm = DB.VoiceMessages.ToList();
                if(vm.Count > 0) 
                    DBLabel.Text = "DB: " + vm.First().Message.ToString();

                if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
                {
                    // TODO Inform your user
                    return;
                }

                if (!_audioRecorder.IsRecording)
                {
                    await _audioRecorder.StartAsync();

                    await CounterBtn.ScaleTo(1.2d, 200);
                    await CounterBtn.ScaleTo(1.0d, 200);

                    CounterBtn.Source = "pause.png";
                }
                else
                {
                    var recordedAudio = await _audioRecorder.StopAsync();

                    await CounterBtn.ScaleTo(1.2d, 200);
                    await CounterBtn.ScaleTo(1.0d, 200);

                    CounterBtn.Source = "play.png";

                    using(var fs = recordedAudio.GetAudioStream())
                    using(var br = new BinaryReader(fs))
                    {
                        int array = int.MaxValue;
                        byte[] bytes = new byte[fs.Length];
                        await fs.ReadAsync(bytes, 0, (int)fs.Length);

                        DB.VoiceMessages.Add(new VoiceMessage { Id = 10, Message = bytes, DateTime = DateTime.Now });
                        DB.SaveChanges();
                        audioFile = bytes;
                    }

                   

                    var player = AudioManager.Current.CreatePlayer(recordedAudio.GetAudioStream());
                    player.Play();
                }








            //count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
