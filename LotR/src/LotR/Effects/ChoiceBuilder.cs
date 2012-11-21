﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LotR.States;

namespace LotR.Effects
{
    public class ChoiceBuilder<TSource>
        : IChoiceBuilder
        where TSource: class, ISource
    {
        public ChoiceBuilder(string text, TSource source, IPlayer player)
            : this(text, source, player, false)
        {
        }

        public ChoiceBuilder(string text, TSource source, IPlayer player, bool isOptional)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            if (source == null)
                throw new ArgumentNullException("source");
            if (player == null)
                throw new ArgumentNullException("player");

            this.text = text;
            this.source = source;
            this.player = player;
            this.isOptional = isOptional;
        }

        private readonly string text;
        private readonly TSource source;
        private readonly IPlayer player;
        private readonly bool isOptional;

        private Question<TSource> question;
        private Question<TSource> lastQuestion;
        private Question<TSource> savedQuestion;
        private Answer<TSource> lastAnswer;

        public IChoiceBuilder Question(string text)
        {
            return Question(text, 1, 1);
        }

        public IChoiceBuilder Question(string text, uint minimumChosenAnswers, uint maximumChosenAnswers)
        {
            if (question == null)
            {
                question = new Question<TSource>(text, source, player);
                lastQuestion = question;
            }
            else if (lastAnswer != null)
            {
                var followUpQuestion = new Question<TSource>(text, source, player, minimumChosenAnswers, maximumChosenAnswers);
                lastAnswer.AddFollowUp(followUpQuestion);

                savedQuestion = lastQuestion;
                lastQuestion = followUpQuestion;
            }
            else
                throw new InvalidOperationException("There is already a question defined, with no answers. A follow-up question must be preceded by an answer");

            return this;
        }

        public IChoiceBuilder Answer<TItem>(string text, TItem item)
        {
            return Answer<TItem>(text, item, null);
        }

        public IChoiceBuilder Answer<TItem>(string text, TItem item, Action<IGame, IEffectHandle, TItem> executeFunction)
        {
            if (lastQuestion == null)
                throw new InvalidOperationException("There is no question defined. A answer must be preceded by a question");
            
            var answer = new Answer<TSource, TItem>(text, source, item, executeFunction);
            lastQuestion.AddAnswer(answer);
            lastAnswer = answer;

            return this;
        }

        public IChoiceBuilder Answers<TItem>(IEnumerable<TItem> items, Func<TItem, string> getText, Action<IGame, IEffectHandle, TItem> executeFunction)
        {
            if (lastQuestion == null)
                throw new InvalidOperationException("There is no question defined. A answer must be preceded by a question");

            foreach (var item in items)
            {
                var answer = new Answer<TSource, TItem>(getText(item), source, item, executeFunction);
                lastQuestion.AddAnswer(answer);
                lastAnswer = answer;
            }

            return this;
        }

        public IChoiceBuilder LastAnswer<TItem>(string text, TItem item)
        {
            return LastAnswer<TItem>(text, item, null);
        }

        public IChoiceBuilder LastAnswer<TItem>(string text, TItem item, Action<IGame, IEffectHandle, TItem> executeFunction)
        {
            if (lastQuestion == null)
                throw new InvalidOperationException("There is no question defined. A answer must be preceded by a question");

            var answer = new Answer<TSource, TItem>(text, source, item, executeFunction);
            lastQuestion.AddAnswer(answer);

            lastQuestion = savedQuestion;

            return this;
        }

        public IChoiceBuilder LastAnswers<TItem>(IEnumerable<TItem> items, Func<TItem, string> getText, Action<IGame, IEffectHandle, TItem> executeFunction)
        {
            if (lastQuestion == null)
                throw new InvalidOperationException("There is no question defined. A answer must be preceded by a question");

            foreach (var item in items)
            {
                var answer = new Answer<TSource, TItem>(getText(item), source, item, executeFunction);
                lastQuestion.AddAnswer(answer);
            }

            lastQuestion = savedQuestion;

            return this;
        }

        public IChoice ToChoice()
        {
            return new Choice<TSource>(text, source, question, isOptional);
        }
    }
}
