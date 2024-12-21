﻿using MessagePack;
using MessagePack.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [MessagePackObject(AllowPrivate = true, SuppressSourceGeneration = true)]
    public class PrimaryKey
    {
        [Key(0)]
        private Dictionary<string, IPrimaryKeyItem> itemList = new Dictionary<string, IPrimaryKeyItem>();
    }

    public interface IPrimaryKeyItem
    {
        object ObjectValue
        {
            get;
        }
    }

    [MessagePackObject(AllowPrivate = true, SuppressSourceGeneration = true)]
    public abstract class PrimaryKeyItemBase
    {
        internal abstract void SetValue(object value);
    }

    [MessagePackObject(AllowPrivate = true, SuppressSourceGeneration = true)]
    public  class PrimaryKeyItem<TType> : PrimaryKeyItemBase, IPrimaryKeyItem
    {
        [Key(0)]
        private TType value;

        [SerializationConstructor]
        private PrimaryKeyItem()
        {

        }
        public PrimaryKeyItem(TType value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            this.value = value;
        }

        [IgnoreMember]
        public object ObjectValue
        {
            get
            {
                return value;
            }
        }


        internal override void SetValue(object value)
        {
            this.value = (TType)value;
        }
    }




}
