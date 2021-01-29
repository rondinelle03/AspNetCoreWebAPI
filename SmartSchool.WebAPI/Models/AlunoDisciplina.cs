namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina()
        {

        }
        public AlunoDisciplina(int alunoId, int discilinaId)
        {
            this.AlunoId = alunoId;
            this.DiscilinaId = discilinaId;
            

        }
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int DiscilinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}