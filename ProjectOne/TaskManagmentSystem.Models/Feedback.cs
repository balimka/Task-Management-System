using System;
using TaskManagmentSystem.Models.Common;
using TaskManagmentSystem.Models.Contracts;
using TaskManagmentSystem.Models.Enums.Feedback;

namespace TaskManagmentSystem.Models
{
    public class Feedback : BoardItem, IFeedback
    {
        private int rating;
        private Status status;

        public Feedback(int id, string title, string description, int rating)
            : base(id, title, description, "Feedback")
        {
            this.Rating = rating;
            this.Status = Status.New;
        }

        public int Rating
        {
            get => this.rating;
            private set
            {
                Validator.ValidateRange(value, Constants.RATING_MIN_VALUE, Constants.RATING_MAX_VALUE, Constants.RATING_OUTOFRANGE_ERR);
                this.rating = value;
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

        public override void ChangeStatus()
        {
            _ = this.status != Status.Done ? status++ : status = Status.New;
            AddEvent(new EventLog($"Status for ID {this.Id} {this.Title} was changed to {this.Status}"));
        }

        public void ChangeRating(string number)
        {
            this.Rating = Validator.ParseIntParameter(number);
            AddEvent(new EventLog($"Rating for ID {this.Id} {this.Title} was changed to {this.Rating}"));
        }

        public override string ToString()
        {
            return "Feedback: " + base.ToString();
        }

        protected override string AddAdditionalInfo()
        {
            return $"Status: {this.Status} {Environment.NewLine} Rating: {this.Rating}";
        }
    }
}
