using System;
using System.Collections.Generic;
using System.Text;

namespace CommonUtils.Abstractions.Entity
{
    class SoftDeleteableEntity : BaseEntity
    {
        public bool isDeleted { get; private set; }

        public void DeleteEntity()
        {
            isDeleted = true;
        }

        public void RestoreEntity()
        {
            isDeleted = false;
        }
    }
}
