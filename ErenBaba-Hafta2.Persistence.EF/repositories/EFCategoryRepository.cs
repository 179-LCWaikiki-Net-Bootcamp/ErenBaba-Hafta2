using ErenBaba_Hafta2.Core.data;
using ErenBaba_Hafta2.Domain;
using ErenBaba_Hafta2.Domain.repositories;
using ErenBaba_Hafta2.Persistence.EF.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenBaba_Hafta2.Persistence.EF.repositories
{
   public class EFCategoryRepository:EFBaseRepository<Category,AppDbContext>,ICategoryRepository
    {
        public EFCategoryRepository(AppDbContext appDbContext):base(appDbContext)
        {
                
        }
    }
}
