using System.Linq;
using System.Web.Http;
using System.Web.Http.Data.EntityFramework;

namespace PersonalManagerApp.Controllers
{
    public partial class PersonalManagerAppController : DbDataController<PersonalManagerApp.Models.PersonalManagerAppContext>
    {
        public IQueryable<PersonalManagerApp.Models.TodoItem> GetTodoItems() {
            return DbContext.TodoItems.OrderBy(t => t.TodoItemId);
        }

        public void InsertTodoItem(PersonalManagerApp.Models.TodoItem entity) {
            InsertEntity(entity);
        }

        public void UpdateTodoItem(PersonalManagerApp.Models.TodoItem entity) {
            UpdateEntity(entity);
        }

        public void DeleteTodoItem(PersonalManagerApp.Models.TodoItem entity) {
            DeleteEntity(entity);
        }
    }
}
