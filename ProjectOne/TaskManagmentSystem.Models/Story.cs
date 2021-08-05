﻿using System;
using TaskManagmentSystem.Models.Common;
using TaskManagmentSystem.Models.Contracts;
using TaskManagmentSystem.Models.Enums;
using TaskManagmentSystem.Models.Enums.Story;

namespace TaskManagmentSystem.Models
{
    public class Story : BoardItem, IStory
    {
        private Priority priority;
        private Size size;
        private Status status;

        public Story(int id, string title, string description)
            : base(id, title, description, "Story")
        {
            this.Priority = Priority.Low;
            this.Size = Size.Small;
            this.Status = Status.NotDone;
        }

        public Priority Priority
        {
            get => this.priority;
            private set
            {
                this.priority = value;
            }
        }

        public Size Size
        {
            get => this.size;
            private set
            {
                this.size = value;
            }
        }

        public Status Status
        {
            get => this.status;
            private set
            {
                this.status = value;
            }
        }

        public IMember Assignee { get; private set; }

        public void AddAssignee(IMember assignee)
        {
            Validator.ValidateObjectIsNotNULL(assignee, string.Format(Constants.ITEM_NULL_ERR, "Assignee"));
            this.Assignee = assignee;
            AddEvent(new EventLog($"Assignee {assignee.Id} was assigneed to ID: {this.Id}, Story {this.Title}"));
        }

        public void ChangeSize()
        {
            this.size = this.size != Size.Large ? size++ : Size.Small;
            AddEvent(new EventLog($"Size for ID {this.Id} {this.Title} was changed to {this.Size}"));
        }

        public void ChangePriority()
        {
            this.priority = this.priority != Priority.High ? priority++ : Priority.Low;
            AddEvent(new EventLog($"Priority for ID {this.Id} {this.Title} was changed to {this.Priority}"));
        }

        public override void ChangeStatus()
        {
            this.status = this.status != Status.Done ? status++ : Status.NotDone;
            AddEvent(new EventLog($"Status for ID {this.Id} {this.Title} was changed to {this.Status}"));
        }

        public override string ToString()
        {
            return "Story: " + base.ToString();
        }
        protected override string AddAdditionalInfo()
        {
            return $"Assignee {this.Assignee.Name} {Environment.NewLine} Status: {this.Status} {Environment.NewLine} Priority: {this.Priority} {Environment.NewLine} Size: {this.Size} ";
        }
    }
}