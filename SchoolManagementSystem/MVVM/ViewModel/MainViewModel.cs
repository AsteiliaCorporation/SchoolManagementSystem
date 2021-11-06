using System;
using SchoolManagementSystem.Core;

namespace SchoolManagementSystem.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        #region Global Variables

        public AuthorizationViewModel AuthorizationVM;
        public PrimaryViewModel PrimaryVM;
        public SettingsViewModel SettingsVM;
        public HomeViewModel HomeVM;
        public LogbookViewModel LogbookVM;
        public TasksViewModel TasksVM;
        public StatisticsViewModel StatisticsVM;
        public ActivitiesViewModel ActivitiesVM;
        public MaterialsViewModel MaterialsVM;
        public TestsViewModel TestsVM;
        public EventsViewModel EventsVM;
        public CompetitionsViewModel CompetitionsVM;
        public OfficeWorkViewModel OfficeWorkVM;
        public AdministrationViewModel AdministrationVM;
        public MobileAppViewModel MobileAppVM;
        public AccountViewModel AccountVM;

        #endregion

        public MainViewModel()
        {
            AuthorizationVM = new AuthorizationViewModel();
            PrimaryVM = new PrimaryViewModel();
            SettingsVM = new SettingsViewModel();
            HomeVM = new HomeViewModel();
            LogbookVM = new LogbookViewModel();
            TasksVM = new TasksViewModel();
            StatisticsVM = new StatisticsViewModel();
            ActivitiesVM = new ActivitiesViewModel();
            MaterialsVM = new MaterialsViewModel();
            TestsVM = new TestsViewModel();
            EventsVM = new EventsViewModel();
            CompetitionsVM = new CompetitionsViewModel();
            OfficeWorkVM = new OfficeWorkViewModel();
            AdministrationVM = new AdministrationViewModel();
            MobileAppVM = new MobileAppViewModel();
            AccountVM = new AccountViewModel();
        }
    }
}
