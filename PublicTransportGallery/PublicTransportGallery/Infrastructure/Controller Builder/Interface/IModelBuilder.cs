﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface
{
    public interface IModelBuilderExecuteReturnModel<T>
    {
        T Execute(T model);
    }
}
