using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarPack.DAL.Repository;
using ToolDataBase;

namespace InOutFCA.DAL.Repository
{
    public class UnitOfWork
    {
        public static UnitOfWork _instance = null;
        public static UnitOfWork Instance
        {
            get { return _instance = _instance ?? new UnitOfWork(); }
        }

        private DBConnect _db;



        #region ClientRepository

        private ClientRepository _clientRepository;

        public ClientRepository ClientRepository
        {
            get
            {
                return _clientRepository = _clientRepository ?? new ClientRepository(_db, "tbclient");
            }
        }
        #endregion
        #region EventRepository

        private EventRepository _eventRepository;

        public EventRepository EventRepository
        {
            get
            {
                return _eventRepository = _eventRepository ?? new EventRepository(_db, "tbevent");
            }
        }
        #endregion
        #region VehicleRepository

        private VehicleRepository _vehicleRepository;

        public VehicleRepository VehicleRepository
        {
            get
            {
                return _vehicleRepository = _vehicleRepository ?? new VehicleRepository(_db, "tbvehicle");
            }
        }
        #endregion
        #region UserRepository

        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {
                return _userRepository = _userRepository ?? new UserRepository(_db, "tbuser");
            }
        }
        #endregion
        #region ReasonRepository

        private ReasonRepository _reasonRepository;

        public ReasonRepository ReasonRepository
        {
            get
            {
                return _reasonRepository = _reasonRepository ?? new ReasonRepository(_db, "tbreason");
            }
        }

        //public object Tbl_logRepository { get; set; }
        #endregion
        #region Tbl_logRepository

        private Tbl_logRepository _tbl_logRepository;

        public Tbl_logRepository Tbl_logRepository
        {
            get
            {
                return _tbl_logRepository = _tbl_logRepository ?? new Tbl_logRepository(_db, "tbl_log");
            }
        }

        //public object Tbl_logRepository { get; set; }
        #endregion
        #region ProfilRepository

        private ProfilRepository _profilRepository;

        public ProfilRepository ProfilRepository
        {
            get
            {
                return _profilRepository = _profilRepository ?? new ProfilRepository(_db, "tbprofil");
            }
        }
        #endregion
        #region EventActionRepository

        private EventActionRepository _eventActionRepository;

        public EventActionRepository EventActionRepository
        {
            get
            {
                return _eventActionRepository = _eventActionRepository ?? new EventActionRepository(_db, "tb_eventaction");
            }
        }
        #endregion
        #region UserprofilRepository

        private UserprofilRepository _userprofilRepository;

        public UserprofilRepository UserprofilRepository
        {
            get
            {
                return _userprofilRepository = _userprofilRepository ?? new UserprofilRepository(_db, "tb_userprofil");
            }
        }
        #endregion
        #region DepartmentRepository

        private DepartmentRepository _departmentRepository;

        public DepartmentRepository DepartmentRepository
        {
            get
            {
                return _departmentRepository = _departmentRepository ?? new DepartmentRepository(_db, "tbdepartment");
            }
        }
        #endregion
        #region ReportRepository

        private ReportRepository _reportRepository;

        public ReportRepository ReportRepository
        {
            get
            {
                return _reportRepository = _reportRepository ?? new ReportRepository(_db, "tbreport");
            }
        }
        #endregion
        private UnitOfWork()
        {
            _db = new DBConnect(@"Server=localhost; Database=CarPack; Uid=root; Pwd=ephec;SslMode=none;");
        }
    }
}
//db.ms_student
//.Where(s => s.ms_course.ms_subject
//.Any(sb => sb.subject_id == subject_id)))