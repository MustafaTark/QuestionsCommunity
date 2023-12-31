﻿using Domain.Models.Questions;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contracts
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
    }
}
