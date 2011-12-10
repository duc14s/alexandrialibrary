﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Gnosis.Alexandria.ViewModels;

namespace Gnosis.Alexandria.Views
{
    /// <summary>
    /// Interaction logic for PlaylistView.xaml
    /// </summary>
    public partial class PlaylistView : UserControl
    {
        public PlaylistView()
        {
            InitializeComponent();
        }

        private ILogger logger;
        private IPlaylistViewModel playlist;

        public void Initialize(ILogger logger, IPlaylistViewModel playlist)
        {
            if (logger == null)
                throw new ArgumentNullException("logger");
            if (playlist == null)
                throw new ArgumentNullException("playlist");

            this.logger = logger;

            try
            {
                this.playlist = playlist;
                this.DataContext = playlist;

                var first = playlist.Items.FirstOrDefault();
                if (first != null)
                {
                    first.IsPlaying = true;
                    first.IsSelected = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error("PlaylistView.Initialize", ex);
            }
        }

        public void OnItemStarted(ITaskViewModel task)
        {
            var existing = playlist.Items.Where(x => x.IsPlaying).FirstOrDefault();
            if (existing != null)
            {
                existing.IsPlaying = false;
            }

            var playing = playlist.Items.Where(x => x.Id == task.CurrentItem.Id).FirstOrDefault();
            if (playing != null)
            {
                playing.IsPlaying = true;
            }
        }

        public void OnItemChanged(TaskItem item)
        {
            var existing = playlist.Items.Where(x => x.IsPlaying).FirstOrDefault();
            if (existing != null)
            {
                existing.IsPlaying = false;
            }

            var playing = playlist.Items.Where(x => x.Id == item.Id).FirstOrDefault();
            if (playing != null)
            {
                playing.IsPlaying = true;
            }
        }

        public void OnItemEnded(TaskItem item)
        {
            try
            {
                var playing = playlist.Items.Where(x => x.Id == item.Id).FirstOrDefault();
                if (playing != null)
                {
                    playing.IsPlaying = false;
                }
            }
            catch (Exception ex)
            {
                logger.Error("  PlaylistView.HandlePlaylistResult", ex);
            }
        }
    }
}