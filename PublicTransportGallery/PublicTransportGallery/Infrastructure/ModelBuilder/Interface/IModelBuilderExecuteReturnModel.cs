using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.Interface
{
    public interface IModelBuilderExecuteRebuild<T>
    {
        T Execute(T model);
        T Rebuild();
    }
}
