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
    
    public partial class Продавец_Товар__Выручка_
    {
        public int id_выручки { get; set; }
        public int id_продавца { get; set; }
        public int id_товара { get; set; }
        public string Дата_продажи { get; set; }
        public string Кол_во_продан__товара { get; set; }
    
        public virtual Продавец Продавец { get; set; }
        public virtual Товар Товар { get; set; }
    }
}
