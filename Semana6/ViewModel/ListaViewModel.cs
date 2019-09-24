using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Semana6.ViewModel
{
	public class ListaViewModel : ViewModelBase
	{
		ObservableCollection<Categoria> _Categorias;
		public ObservableCollection<Categoria> Categorias
		{
			get { return _Categorias; }
			set
			{
				if (_Categorias != value)
				{
					_Categorias = value;
					OnPropertChanged();
				}
			}
		}
		public ICommand NuevoCommand { get; set; }
		public ICommand ConsultarCommand { get; set; }
		public ListaViewModel()
		{
			Categorias = new Model.CategoriaModel().Categorias;

			NuevoCommand = new RelayCommand<Window>
			(
				param => Abrir()
			);

			ConsultarCommand = new RelayCommand<object>(
				o => { Categorias = (new Model.CategoriaModel()).Categorias; }
				);

			void Abrir()
			{
				View.ManCategoria window = new View.ManCategoria();
				window.ShowDialog();
			}
		}
	}
}
