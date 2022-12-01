namespace GazoFicationAndWaterWeb.Data
{
    public class MemberService
    {
        public Members? members { get; set; }

        public Members? Get()
        {
            return members;
        }

        public Members Set(Members mem)
        {
            this.members = mem;
            return members;
        }
    }
}
