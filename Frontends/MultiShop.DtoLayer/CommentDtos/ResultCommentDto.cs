﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CommentDtos
{
    public class ResultCommentDto
    {
        public int UserCommentId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }
        public string CommentDetail { get; set; }
        public int Raiting { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductId { get; set; }
    }
}
