﻿using SnippetGUI.Data;
using SnippetGUI.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SnippetGUI.ViewModel
{
    /// <summary>
    /// ViewModel for the MainWindow
    /// </summary>
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        private readonly IDataAccess dataAccess;

        private string _title;
        /// <summary>
        /// The title of the snippet
        /// </summary>
        public string Title
        {
            get => _title;
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _author;
        /// <summary>
        /// The author of the snippet
        /// </summary>
        public string Author
        {
            get => _author;
            set
            {
                if (_author != value)
                {
                    _author = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _description;
        /// <summary>
        /// The description of the snippet
        /// </summary>
        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _shortcut;
        /// <summary>
        /// The shortcut to access the snippet
        /// </summary>
        public string Shortcut
        {
            get => _shortcut;
            set
            {
                if (_shortcut != value)
                {
                    _shortcut = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _language;
        /// <summary>
        /// The language the snippet applies to
        /// </summary>
        public string Language
        {
            get => _language;
            set
            {
                if (_language != value)
                {
                    _language = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _code;
        /// <summary>
        /// The code for the snippet
        /// </summary>
        public string Code
        {
            get => _code;
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _languages;
        /// <summary>
        /// Available languages that the snippet can be coded in
        /// </summary>
        public ObservableCollection<string> Languages
        {
            get => _languages;
            set
            {
                if (_languages != value)
                {
                    _languages = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Declaration Properties

        private string _declarationID;
        /// <summary>
        /// ID of the selected declaration
        /// </summary>
        public string DeclarationID
        {
            get => _declarationID;
            set
            {
                if (_declarationID != value)
                {
                    _declarationID = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _declarationDefaultValue;
        /// <summary>
        /// Default value of the selected declaration
        /// </summary>
        public string DeclarationDefaultValue
        {
            get => _declarationDefaultValue;
            set
            {
                if (_declarationDefaultValue != value)
                {
                    _declarationDefaultValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _declarationToolTip;
        /// <summary>
        /// Tool tip of the selected declaration
        /// </summary>
        public string DeclarationToolTip
        {
            get => _declarationToolTip;
            set
            {
                if (_declarationToolTip != value)
                {
                    _declarationToolTip = value;
                    OnPropertyChanged();
                }
            }
        }

        private Declaration _declaration;
        /// <summary>
        /// Currently selected declaration
        /// </summary>
        public Declaration Declaration
        {
            get => _declaration;
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<Declaration> _declarations;
        /// <summary>
        /// All declarations in the snippet
        /// </summary>
        public ObservableCollection<Declaration> Declarations
        {
            get => _declarations;
            set
            {
                if (_declarations != value)
                {
                    _declarations = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        private string _snippet;
        /// <summary>
        /// The generated code snippet
        /// </summary>
        public string Snippet
        {
            get => _snippet;
            set
            {
                if (_snippet != value)
                {
                    _snippet = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _saveLocation;
        /// <summary>
        /// Location to save the snippet
        /// </summary>
        public string SaveLocation
        {
            get => _saveLocation;
            set
            {
                if (_saveLocation != value)
                {
                    _saveLocation = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Construct a new MainViewModel
        /// </summary>
        /// <param name="dataAccess"> Data Access for config files </param>
        /// <param name="snippetBuilder"> Snippet Builder to generate snippet </param>
        public MainViewModel(IDataAccess dataAccess)
        {
            this.dataAccess = dataAccess ?? new DataAccess();

            Languages = new ObservableCollection<string>(this.dataAccess.GetLanguages());
            Declarations = new ObservableCollection<Declaration>();
        }

        /// <summary>
        /// Construct a new MainViewModel with default dataaccess and snippetbuilders
        /// </summary>
        /// <remarks> can't be done w/ defaults as it throws null reference on InitializeComponent() </remarks>
        public MainViewModel() : this(new DataAccess()) { }

        #endregion

        #region ICommands

        /// <summary>
        /// Generate a code snippet
        /// </summary>
        public ICommand GenerateSnippetCmd
            => new RelayCommand<object>(x => GenerateSnippet(),
                x => SnippetBuilder.ValidSnippet(Languages, Language, Code));

        /// <summary>
        /// Save a snippet
        /// </summary>
        public ICommand SaveSnippetCmd
            => new RelayCommand<object>(x => SaveSnippet(), x => CanSaveSnippet());

        /// <summary>
        /// Add a new declaration to Declarations
        /// </summary>
        public ICommand NewDeclarationCmd
            => new RelayCommand<Declaration>(x => NewDeclaration(),
                x => Declaration.ValidDeclaration(Declarations, DeclarationID, DeclarationDefaultValue));

        public ICommand DeleteDeclarationCmd
            => new RelayCommand<Declaration>(x => DeleteDeclaration(),
                x => Declaration != null);

        #endregion

        #region Methods

        /// <summary>
        /// Generate a snippet
        /// </summary>
        private void GenerateSnippet()
        {
            var snippetBuilder = new SnippetBuilder(Title, Author,
                Description, Shortcut, Language, Code, Declarations, dataAccess);
            Snippet = snippetBuilder.GenerateSnippet();
        }

        /// <summary>
        /// Save a snippet to a file
        /// </summary>
        private void SaveSnippet()
        {
            var snippetFile = new SnippetFile(SaveLocation, Snippet);
            snippetFile.Save();
        }

        /// <summary>
        /// Add a new declaration to Declarations
        /// </summary>
        private void NewDeclaration()
        {
            var declaration = new Declaration(DeclarationID, DeclarationDefaultValue, DeclarationToolTip);
            Declarations.Add(declaration);

            DeclarationID = null;
            DeclarationDefaultValue = null;
            DeclarationToolTip = null;
        }

        /// <summary>
        /// Deletes the selected declaration
        /// </summary>
        private void DeleteDeclaration()
        {
            Declarations.Remove(Declaration);
        }

        /// <summary>
        /// Determines whether a snippet file can be saved
        /// </summary>
        /// <returns> True if the snippet can be saved </returns>
        private bool CanSaveSnippet() => !(string.IsNullOrEmpty(SaveLocation) || string.IsNullOrEmpty(Snippet));

        #endregion
    }
}