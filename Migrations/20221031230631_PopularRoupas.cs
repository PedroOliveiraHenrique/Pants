using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NetPants.Migrations
{
    public partial class PopularRoupas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Roupas(CategoriaId, Nome, Marca, Descricaocurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsRoupaPromocao, EmEstoque) VALUES(1, 'Camisa', 'Nike', 'Camisa Polo', 'Perfeita opção para ocasiões especiais', 120.00, 'ImgUrl', 'ImgThumb', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Roupas(CategoriaId, Nome, Marca, Descricaocurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsRoupaPromocao, EmEstoque) VALUES(2, 'tênis', 'Adidas', 'Tênis esportivo', 'Perfeita opção para praticar atividade física', 150.00, 'ImgUrl', 'ImgThumb', 0, 1)");
            migrationBuilder.Sql("INSERT INTO Roupas(CategoriaId, Nome, Marca, Descricaocurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsRoupaPromocao, EmEstoque) VALUES(1, 'Camisa', 'Lacoste', 'Camisa executiva', 'Perfeita opção para reunões importantes', 230.00, 'ImgUrl', 'ImgThumb', 1, 1)");
            migrationBuilder.Sql("INSERT INTO Roupas(CategoriaId, Nome, Marca, Descricaocurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsRoupaPromocao, EmEstoque) VALUES(1, 'Calça', 'Nike', 'Calça elastano', 'Perfeita opção para dias frios', 65.00, 'ImgUrl', 'ImgThumb', 0, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Roupas");
        }
    }
}
