#r "nuget: NAudio, 2.1.0"

using NAudio.Wave;

int sampleRate = 44100;
int frequency = 500;
int duration = 5000;

int samples = sampleRate * duration / 1000;
var waveFormat = new WaveFormat(sampleRate, 16, 1);
var waveFile = new WaveFileWriter("beep.wav", waveFormat);

for (int i = 0; i < samples; i++)
{
    float sample = (float)
        Math.Sin(2 * Math.PI * frequency * i / sampleRate);
    waveFile.WriteSample(sample);
}
waveFile.Close();
