using log4net;
using log4net.Config;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Swd.TimeManager.Model;
using Swd.TimeManager.Repository;
using Task = Swd.TimeManager.Model.Task;

namespace Swd.TimeManager.Test
{

    [TestClass]
    public class RepositoryTest
    {
        //Test
        private static readonly ILog log = LogManager.GetLogger(typeof(RepositoryTest));


        public RepositoryTest() {

        }


        [TestInitialize()]
        public void Startup()
        {
            XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            log.Debug("Logging started");
        }



        [TestCleanup()]
        public void Cleanup()
        {
            
        }



        [TestMethod]
        public void Add_Project()
        {
            //Testwerte vorbereiten
            Project item = GetNewProject();

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task Add_ProjectAsync()
        {
            //Testwerte vorbereiten
            Project item = GetNewProject();

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public void ReadByKey_Project()
        {
            //Testwerte vorbereiten
            Project item = GetNewProject();

            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);

            long id = item.Id;
            Project newProject = repository.ReadByKey(id);   

            //Test auswerten
            Assert.AreEqual(id, newProject.Id);
        }


        [TestMethod]
        public void ReadAll_Project()
        {
            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            List<Project> resultList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task ReadAllAsync_Project()
        {
            //Test durchführen
            ProjectRepository repository = new ProjectRepository();
            List<Project> resultList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public void Delete_Project()
        {
            //Testwerte vorbereiten
            Project item = GetNewProject();
            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);
            long id = item.Id;

            //Test durchführen
            repository.Delete(id);

            Project deletedProject = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedProject);
        }


        [TestMethod]
        public void Update_Project()
        {
            //Testwerte vorbereiten
            Project item = GetNewProject();

            ProjectRepository repository = new ProjectRepository();
            repository.Add(item);

            long id = item.Id;
            string createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "Updated";
            repository.Update(item, id);
            Project updatedItem = repository.ReadByKey(id);


            //Test auswerten
            Assert.AreNotEqual(createdBy, updatedItem.CreatedBy);
        }







        [TestMethod]
        public void Add_Task()
        {




            //Testwerte vorbereiten
            Task item = GetNewTask();

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task Add_TaskAsync()
        {
            //Testwerte vorbereiten
            Task item = GetNewTask();

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }

        [TestMethod]
        public void ReadAll_Task()
        {
            //Test durchführen
            TaskRepository repository = new TaskRepository();
            List<Task> resultList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task ReadAllAsync_Task()
        {
            //Test durchführen
            TaskRepository repository = new TaskRepository();
            List<Task> resultList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public void ReadByKey_Task()
        {
            //Testwerte vorbereiten
            Task item = GetNewTask();

            //Test durchführen
            TaskRepository repository = new TaskRepository();
            repository.Add(item);

            long id = item.Id;
            Task newTask = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newTask.Id);
        }


        [TestMethod]
        public void Delete_Task()
        {
            //Testwerte vorbereiten
            Task item = GetNewTask();
            TaskRepository repository = new TaskRepository();
            repository.Add(item);
            long id = item.Id;

            //Test durchführen
            repository.Delete(id);

            Task deletedItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedItem);
        }


        [TestMethod]
        public void Update_Task()
        {
            //Testwerte vorbereiten
            Task item = GetNewTask();

            TaskRepository repository = new TaskRepository();
            repository.Add(item);

            long id = item.Id;
            string createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "Updated";
            repository.Update(item, id);
            Task updatedItem = repository.ReadByKey(id);


            //Test auswerten
            Assert.AreNotEqual(createdBy, updatedItem.CreatedBy);
        }







        [TestMethod]
        public void Add_TimeRecord()
        {
            PersonRepository personRepository = new PersonRepository();
            TaskRepository taskRepository = new TaskRepository();   
            ProjectRepository projectRepository = new ProjectRepository();

            Person person = personRepository.ReadAll().FirstOrDefault();
            Task task = taskRepository.ReadAll().FirstOrDefault();
            Project project = projectRepository.ReadAll().FirstOrDefault();


            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();

            //Variante 1: Legt Person, Project Task neu an weil Objekte neu
            //item.Person = GetNewPerson();
            //item.Project = GetNewProject();

            //Variante 2: Objekte bestehen bereits, Fehler
            //item.Person = person;
            //item.Project = project;
            //item.Task = task;

            //Variante 3: Objekte bestehen bereits, ForeignKey Feld wird verwendet
            //item.PersonId = person.Id;
            //item.ProjectId = project.Id;
            //item.TaskId = task.Id;




            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task Add_TimeRecordAsync()
        {



            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();




            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public void ReadAll_TimeRecord()
        {
            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            List<TimeRecord> resultList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task ReadAllAsync_TimeRecord()
        {
            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            List<TimeRecord> resultList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public void ReadByKey_TimeRecord()
        {
            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);

            long id = item.Id;
            TimeRecord newItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newItem.Id);
        }

        [TestMethod]
        public void ReadByKeyInclusive_TimeRecord()
        {
            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();

            //Test durchführen
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);

            long id = item.Id;
            TimeRecord newItem = repository.ReadByKeyInklusive(id);

            //Test auswerten
            Assert.AreEqual(id, newItem.Id);
        }


        [TestMethod]
        public void Delete_TimeRecord()
        {
            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();
            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);
            long id = item.Id;

            //Test durchführen
            repository.Delete(id);

            TimeRecord deletedItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedItem);
        }


        [TestMethod]
        public void Update_TimeRecord()
        {
            //Testwerte vorbereiten
            TimeRecord item = GetNewTimeRecord();

            TimeRecordRepository repository = new TimeRecordRepository();
            repository.Add(item);

            long id = item.Id;
            string createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "Updated";
            repository.Update(item, id);
            TimeRecord updatedItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updatedItem.CreatedBy);
        }





        [TestMethod]
        public void Add_Person()
        {
            //Testwerte vorbereiten
            Person item = GetNewPerson();

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            repository.Add(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task Add_PersonAsync()
        {
            //Testwerte vorbereiten
            Person item = GetNewPerson();

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            await repository.AddAsync(item);

            //Test auswerten
            Assert.AreNotEqual(0, item.Id);
        }


        [TestMethod]
        public void ReadAll_Person()
        {
            //Test durchführen
            PersonRepository repository = new PersonRepository();
            List<Person> resultList = repository.ReadAll().ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public async System.Threading.Tasks.Task ReadAllAsync_Person()
        {
            //Test durchführen
            PersonRepository repository = new PersonRepository();
            List<Person> resultList = (await repository.ReadAllAsync()).ToList();

            //Test auswerten
            Assert.AreNotEqual(0, resultList.Count);
        }


        [TestMethod]
        public void ReadByKey_Person()
        {
            //Testwerte vorbereiten
            Person item = GetNewPerson();

            //Test durchführen
            PersonRepository repository = new PersonRepository();
            repository.Add(item);

            long id = item.Id;
            Person newTask = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreEqual(id, newTask.Id);
        }


        [TestMethod]
        public void Delete_Person()
        {
            //Testwerte vorbereiten
            Person item = GetNewPerson();
            PersonRepository repository = new PersonRepository();
            repository.Add(item);
            long id = item.Id;

            //Test durchführen
            repository.Delete(id);

            Person deletedItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.IsNull(deletedItem);
        }


        [TestMethod]
        public void Update_Person()
        {
            //Testwerte vorbereiten
            Person item = GetNewPerson();

            PersonRepository repository = new PersonRepository();
            repository.Add(item);

            long id = item.Id;
            string createdBy = item.CreatedBy;

            //Test durchführen
            item.CreatedBy = "Updated";
            repository.Update(item, id);
            Person updatedItem = repository.ReadByKey(id);

            //Test auswerten
            Assert.AreNotEqual(createdBy, updatedItem.CreatedBy);
        }




        private Project GetNewProject()
        {
            Project item = new Project();
            item.Name = string.Format("Project {0}",DateTime.Now);
            //item.Created = DateTime.Now; -> Wird im Repository gesetzt
            item.CreatedBy = "marcel.butterweck";
            return item;
        }


        private Task GetNewTask()
        {
            Task item = new Task();
            item.Name = string.Format("Task {0}", DateTime.Now);
            //item.Created = DateTime.Now; -> Wird im Repository gesetzt
            item.CreatedBy = "marcel.butterweck";
            return item;
        }


        private Person GetNewPerson()
        {

            Person item = new Person();
            item.FirstName = string.Format("Firstname {0}", DateTime.Now);
            item.LastName = string.Format("Lastname {0}", DateTime.Now);
            item.Email = "marcel.butterweck@butterweck.at";
            //item.Created = DateTime.Now; -> Wird im Repository gesetzt
            item.CreatedBy = "marcel.butterweck";
            return item;
        }


        private TimeRecord GetNewTimeRecord()
        {
            PersonRepository personRepository = new PersonRepository();
            TaskRepository taskRepository = new TaskRepository();
            ProjectRepository projectRepository = new ProjectRepository();

            Person person = personRepository.ReadAll().FirstOrDefault();
            Task task = taskRepository.ReadAll().FirstOrDefault();
            Project project = projectRepository.ReadAll().FirstOrDefault();

            TimeRecord item = new TimeRecord();
            item.Date = DateTime.Now;
            item.Duration = 2.0M;
            //item.Created = DateTime.Now; -> Wird im Repository gesetzt
            item.CreatedBy = "marcel.butterweck";

            item.PersonId = person.Id;
            item.ProjectId = project.Id;
            item.TaskId = task.Id;


            return item;
        }

    }
}