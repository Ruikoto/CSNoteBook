using System;
using System.Collections.Generic;
using CSNoteBook.DAO;
using CSNoteBook.Models;

namespace CSNoteBook.Services
{
    public class NoteBookService : INoteBookService
    {
        //��ȡ����
        private readonly INoteBookDao _dao = NoteBookDao.Instance;

        //��ӱʼ�
        public int AddNote(bool isChecked = false,string title = "",string content = "")
        {
            var vChecked = isChecked ? 1 : 0;
            return _dao.AddNote(vChecked,title, content);
        }

        //ɾ���ʼ�
        public void DeleteNote(int id)
        {
            if (_dao.IsNoteExist(id))
            {
                _dao.DeleteNote(id);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }

        //��ȡ�ʼ�
        public Note GetNote(int id)
        {
            if (_dao.IsNoteExist(id))
            {
                return _dao.GetNote(id);
            }
            throw new ArgumentException($"Cannot find index: {id}.");
        }

        //��ȡ���бʼ�
        public List<Note> GetAllNote()
        {
            return _dao.GetAllNote();
        }

        //��ȡ���бʼǵ�����
        public List<int> GetAllNoteIndex()
        {
            return _dao.GetAllNoteIndex();
        }

        //�༭�ʼ�
        public void EditNote(int id, bool isChecked, string title, string content)
        {
            if (_dao.IsNoteExist(id))
            {
                var vChecked = isChecked ? 1 : 0;
                _dao.EditNote(id, vChecked,title, content);
            }
            else
            {
                throw new ArgumentException($"Cannot find index: {id}.");
            }
        }
    }
}