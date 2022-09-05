namespace Models
{
    public class GetClientsResultDto
    {
        public IEnumerable<ClientDto> Data { get; init; }
        public int  Offset { get; init; }

        public GetClientsResultDto(IEnumerable<ClientDto> data, int offset)
        {
            Data = data;
            Offset = offset;
        }
    }
}
