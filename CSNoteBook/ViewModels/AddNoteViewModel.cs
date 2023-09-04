using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CSNoteBook.Models;
using CSNoteBook.Services;

namespace CSNoteBook.ViewModels
{
    public class AddNoteViewModel : INotifyPropertyChanged
    {
        //ģ��
        public Note Model { get; } = new Note();
        //�ύ����
        public ICommand SubmitCommand { get; }

        //���캯��
        public AddNoteViewModel()
        {
            this.SubmitCommand = new RelayCommand(Submit, CanSubmit);
        }

        //�ж��Ƿ�����ύ
        private bool CanSubmit(object obj)
        {
            return !string.IsNullOrEmpty(Model.Title);
        }

        //�ύ
        private void Submit(object obj)
        {
            if (string.IsNullOrEmpty(Model.Title)) return;
            INoteBookService service = new NoteBookService();
            service.AddNote(Model.IsChecked, Model.Title);
            Model.Title = "";
            OnPropertyChanged(nameof(Model));
            NotebookViewModel.Instance.LoadNotes();
        }

        //���Ըı��¼�
        public event PropertyChangedEventHandler PropertyChanged;

        //���Ըı䷽��
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
