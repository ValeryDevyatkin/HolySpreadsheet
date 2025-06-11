﻿using Common.Interfaces;
using Services.Services;
using Unity;

namespace Services
{
    public static class ServicesInitializer
    {
        public static void Init(IUnityContainer container)
        {
            container
               .RegisterSingleton<ISpreadsheetProcessor, SpreadsheetProcessor>()
                ;
        }
    }
}