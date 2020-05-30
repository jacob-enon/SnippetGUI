﻿using SnippetGUI.Data;
using SnippetGUI.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

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
        public RelayCommand<object> GenerateSnippet
            => new RelayCommand<object>(x =>
            {
                var snippetBuilder = new SnippetBuilder(Title, Author, Description, Shortcut, Language, Code, dataAccess);
                Snippet = snippetBuilder.GenerateSnippet();
            });

        /// <summary>
        /// Save a snippet
        /// </summary>
        public RelayCommand<object> SaveSnippet { get; }

        #endregion
    }
}