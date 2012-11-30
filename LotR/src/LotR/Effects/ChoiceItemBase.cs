﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace LotR.Effects
{
    public abstract class ChoiceItemBase<TSource>
        : IChoiceItem, INotifyPropertyChanged
        where TSource : class, ISource
    {
        protected ChoiceItemBase(string text, TSource source)
        {
            this.itemId = Guid.NewGuid();
            this.text = text;
            this.source = source;
        }

        private readonly Guid itemId;
        private readonly string text;
        protected readonly TSource source;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public Guid ItemId
        {
            get { return itemId; }
        }

        public string Text
        {
            get { return text; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
