//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practica2020
{
    using System;
    using System.Collections.Generic;
    
    public partial class Товар
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Товар()
        {
            this.Отдел_товар = new HashSet<Отдел_товар>();
            this.Продавец_Товар__Выручка_ = new HashSet<Продавец_Товар__Выручка_>();
            this.Содержимое_чека = new HashSet<Содержимое_чека>();
        }
    
        public int id_товара { get; set; }
        public string Имя_товара { get; set; }
        public decimal Стоимость_товара_за_1_кг { get; set; }
        public int id_ЕИ { get; set; }
    
        public virtual Единица_измерения Единица_измерения { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Отдел_товар> Отдел_товар { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Продавец_Товар__Выручка_> Продавец_Товар__Выручка_ { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Содержимое_чека> Содержимое_чека { get; set; }
    }
}
