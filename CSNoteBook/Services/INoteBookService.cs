using System.Collections.Generic;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public interface INoteBookService
    {
        //��ӱʼ�
        int AddNote(bool isChecked = false,string title = "",string content = "");
        //ɾ���ʼ�
        void DeleteNote(int id);
        //��ȡ�ʼ�
        Note GetNote(int id);
        //��ȡ���бʼ�
        List<Note> GetAllNote();
        //��ȡ���бʼǵ�����
        List<int> GetAllNoteIndex();
        //�༭�ʼ�
        void EditNote(int id,bool isChecked,string title, string content);
    }
}