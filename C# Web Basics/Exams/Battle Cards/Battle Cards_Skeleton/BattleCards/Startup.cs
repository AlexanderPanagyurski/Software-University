namespace BattleCards
{
    using System.Collections.Generic;
    using BattleCards.Data;
    using BattleCards.Services;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.EnsureCreated();
        }

        public void ConfigureServices(SUS.MvcFramework.IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }
    }
}
