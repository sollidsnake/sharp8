using SFML.Audio;

namespace Sharp8.UI;

public class Audio : IDisposable
{
    private readonly Sound? _sound;
    private readonly SoundBuffer? _soundBuffer;

    public Audio()
    {
        try
        {
            _soundBuffer = new SoundBuffer(@"assets/beep.wav");
            _sound = new Sound(_soundBuffer);
        }
        catch (SFML.LoadingFailedException) { }
    }

    public void Play()
    {
        if (_sound?.Status == SoundStatus.Playing)
        {
            return;
        }
        _sound?.Play();
    }

    public void Stop()
    {
        _sound?.Stop();
    }

    public void Dispose()
    {
        _sound?.Dispose();
        _soundBuffer?.Dispose();

        GC.SuppressFinalize(this);
    }
}
