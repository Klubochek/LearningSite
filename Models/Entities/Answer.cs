﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Learning_Site.Models.Entities
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }
        
        public Question Question { get; set; }
    }
}