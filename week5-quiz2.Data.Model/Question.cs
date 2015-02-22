using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_quiz2.Data.Model
{
    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        public string Title { get; set; }

        public virtual List<QuizOption> QuizOptions { get; set; }
    }
}
