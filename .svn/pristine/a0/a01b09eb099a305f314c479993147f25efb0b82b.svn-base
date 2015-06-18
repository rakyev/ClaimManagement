using System.Collections.Generic;
using AutoMapper;

namespace ICM.Web.Infrastructure
{
    public class ModelAdapter
    {

        public static List<TK> GetConvertedModelList<T, TK>(List<T> source, List<TK> output)
        {
            Mapper.CreateMap<T, TK>();
            foreach (var element in source)
            {
                TK eachItem = Mapper.Map<T, TK>(element);
                output.Add(eachItem);
            }
            return output;
        }

        public static TK GetConvertedModel<T, TK>(T source, TK output)
        {
            Mapper.CreateMap<T, TK>();
            output = Mapper.Map<T, TK>(source);
            return output;
        }
    }
}