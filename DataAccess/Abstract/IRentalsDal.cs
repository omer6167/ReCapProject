﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IRentalsDal : IEntityRepository<Rental>
    {
        List<RentalDetailDto> GetRentalDetails();
        IDataResult<Rental> CheckReturnDate(int carId);
        IDataResult<int> CheckCarId(int carId)
    }
}
