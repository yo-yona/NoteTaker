namespace NoteTaker.Services
{
    public static class NotesServicesExtensions
    {
        public static IServiceCollection AddNotes(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddScoped<INotesServices, NotesServices>();
        }
    }
}
