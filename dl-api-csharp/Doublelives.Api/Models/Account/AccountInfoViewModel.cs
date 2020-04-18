using Doublelives.Shared.Enum;
using System;
using System.Collections.Generic;

namespace Doublelives.Api.Models.Account
{
    public class AccountInfoViewModel
    {
        public List<string> Permissions { get; set; }

        /// <summary>
        /// �˻�������Ϣ
        /// </summary>
        public AccountProfileViewModel Profile { get; set; }

        /// <summary>
        /// ������ʾ���û���
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// todo: ������
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// ����������� ["administrator", "developer"]
        /// </summary>
        public List<string> Roles { get; set; }
    }

    /// <summary>
    /// �˻���Ϣ
    /// </summary>
    public class AccountProfileViewModel
    {
        /// <summary>
        /// ͷ��
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// ��¼�˻���(username)
        /// </summary>
        public string Account { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// ��ֵ
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// ������ʾ���û���
        /// </summary>
        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        /// <summary>
        /// �Ա� 1�� 2Ů
        /// </summary>
        public int? Sex { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        /// <summary>
        /// ��ɫid�� ����Զ������� e.g. (1,2,)
        /// </summary>
        public string Roleid { get; set; }

        /// <summary>
        /// ����id
        /// </summary>
        public long Deptid { get; set; }

        /// <summary>
        /// �˺�״̬ 1���� 2ͣ��
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// �޸ĵİ汾
        /// </summary>
        public long? Version { get; set; }

        /// <summary>
        /// ��ɫid
        /// </summary>
        public long Id { get; set; }

        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// �����˵�id
        /// </summary>
        public long? CreateBy { get; set; }

        public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// �޸��ߵ�id
        /// </summary>
        public long? ModifyBy { get; set; }

        /// <summary>
        /// ������
        /// </summary>
        public string Dept { get; set; }

        /// <summary>
        /// ��ɫ�������� e.g.["��������Ա", "��վ����Ա"]
        /// </summary>
        public List<string> Roles { get; set; }
    }
}