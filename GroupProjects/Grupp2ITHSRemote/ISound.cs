using System;
using System.Collections.Generic;
using System.Text;
using System.Media;

namespace GruppUppgift1
{
    public interface ISound
    {
        SoundPlayer player = new SoundPlayer();

        public void PlaySound(SoundPlayer player)
        {
            player.Play();
        }
        public void PlaySystemSound(SystemSounds s, SystemSound sound)
        {
            s.sound.Play();
        }
    }
}