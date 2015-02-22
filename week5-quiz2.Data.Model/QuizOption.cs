using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week5_quiz2.Data.Model
{
   public class QuizOption
    {
       [Key]
        public int OptionId { get; set; }
        public string Title { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public bool IsCorrect { get; set; }
    }
}
