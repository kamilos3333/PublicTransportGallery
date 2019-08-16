using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.Interface
{
    public interface IModelBuilderImage<T>
    {
        void Execute(HttpPostedFileBase upload, T model);
        T Rebuild(T model);
    }
}
