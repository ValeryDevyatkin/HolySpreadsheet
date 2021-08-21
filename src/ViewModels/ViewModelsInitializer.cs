using Unity;
using ViewModels.ViewModels;

namespace ViewModels
{
    public static class ViewModelsInitializer
    {
        public static void Init(IUnityContainer container)
        {
            container
               .RegisterType<ParserConfigurationViewModel>()
                ;
        }
    }
}