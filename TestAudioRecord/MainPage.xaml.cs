using Plugin.Maui.Audio;

namespace TestAudioRecord
{
    public partial class MainPage : ContentPage
    {
        private readonly IAudioManager _audioManager;
        readonly IAudioRecorder _audioRecorder;
        int count = 0;

        public MainPage(IAudioManager audioManager)
        {
            InitializeComponent();

            _audioManager = audioManager;
            _audioRecorder = _audioManager.CreateRecorder();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            try
            {
                if (await Permissions.RequestAsync<Permissions.Microphone>() != PermissionStatus.Granted)
                {
                    // TODO Inform your user
                    return;
                }

                if (!_audioRecorder.IsRecording)
                {
                    await _audioRecorder.StartAsync();
                }
                else
                {
                    var recordedAudio = await _audioRecorder.StopAsync();

                    var player = AudioManager.Current.CreatePlayer(recordedAudio.GetAudioStream());
                    player.Play();
                }



            } catch(Exception ex) 
            {
                DisplayAlert("Message", ex.Message, "Ok");
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
