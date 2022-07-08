namespace Atacado.Poco.Auxiliar
{
    public class RelatorioAquiculturaPoco
    {
        public int IdAquicultura { get; set; }

        public int IdTipoAquicultura { get; set; }

        public string DescricaoTipoAquicultura { get; set; }

        public int IdMunicipio { get; set; }

        public int Ano { get; set; }

        public int? Producao { get; set; }

        public int? ValorProducao { get; set; }

        public double? ProporcaoValorProporcao { get; set; }

        public string Moeda { get; set; }

        public string NomeMunicipio { get; set;}

        public string SiglaUf { get; set; }

        public string DescricaoUnidadeFederacao { get; set; }

    }
}
