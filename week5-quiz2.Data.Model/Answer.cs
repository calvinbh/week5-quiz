using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_quiz2.Data.Model
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string UserId { get; set; }

        public int QuizOptionId { get; set; }
        public virtual QuizOption QuizOption { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }

    }
}
