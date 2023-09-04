using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CSNoteBook.Models
{
    public class Note : INotifyPropertyChanged
    {
        public int Id { get;  set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsChecked { get; set; }

        //�޲ι���
        public Note()
        {
        }

        //ȫ�ι���
        public Note(int id, string title, string content, bool isChecked)
        {
            Id = id;
            Title = title;
            Content = content;
            IsChecked = isChecked;
        }

        //��дToString����
        public override string ToString()
        {
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (IsChecked)
            {
                return $@"(*)Note #{Id}: Title: {Title}, Content: {Content}";
            }
            else
            {
                return $@"( )Note #{Id}: Title: {Title}, Content: {Content}";
            }

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