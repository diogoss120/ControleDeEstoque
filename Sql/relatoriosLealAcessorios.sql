use controleDeEstoque

--teste para relatório
select	--p.nome 'Produto',
	SUM(	v.TotalVenda )'Total de Vendas',
	SUM(	c.PrecoUni * v.Quantidade) as CustoTotal,
	SUM(	v.TotalVenda - (c.PrecoUni * v.Quantidade)) as Lucro
		--v.dataVenda
from	produto p
join	(
		select v.codProduto ,
		v.dataVenda,
		sum(v.quantidade) as Quantidade ,
		sum(v.valorVenda) as TotalVenda 
		from vendas v 
		group by v.codProduto,v.dataVenda 
		having v.dataVenda between '2020-06-25' and '2020-07-04'
	) v on v.codProduto = p.idProduto
join    (
		select c.codProduto, 
		avg(c.precoUnitario) as PrecoUni 
		from compra c group by c.codProduto--,c.data_compra having c.data_compra = '2020-06-26'
) c	on p.idProduto = c.codProduto


-- teste para relatório versão 1.0
select	p.nome 'Produto',
        v.TotalVenda 'Total de Vendas',
		c.PrecoUni * v.Quantidade as CustoTotal,
		v.TotalVenda - (c.PrecoUni * v.Quantidade) as Lucro,
		v.dataVenda
from	produto p
join	(
	select	v.codProduto ,
			v.dataVenda,
			sum(v.quantidade) as Quantidade ,
			sum(v.valorVenda * v.quantidade) as TotalVenda 
			from vendas v 
			group by v.codProduto,v.dataVenda 
			having v.dataVenda between '2020-06-25' and '2020-07-04'
) v on v.codProduto = p.idProduto
join    (
			select c.codProduto, 
			avg(c.precoUnitario) as PrecoUni 
			from compra c 
			group by c.codProduto
) c	on p.idProduto = c.codProduto


-- teste para relatório versão 2.0
select	p.nome 'Produto',
        v.TotalVenda 'Total de Vendas',
		v.Custo as CustoTotal,
		v.TotalVenda - v.Custo as Lucro,
		v.dataVenda
from	produto p
join	(
	select	v.codProduto ,
			v.dataVenda,
			sum(v.custo) as Custo,
			sum(v.quantidade) as Quantidade ,
			sum(v.valorVenda) as TotalVenda 
			from vendas v 
			group by v.codProduto,v.dataVenda--, v.custo
			having v.dataVenda between '2020-06-25' and '2020-07-04'
) v on v.codProduto = p.idProduto



--versão em uso 'Total por dias'
select	v.dataVenda,
		sum(v.TotalVenda) as 'Total de Vendas',
		sum(v.Custo) as 'Custo total',
		sum(v.TotalVenda - v.Custo) as 'Lucro total'		
from	produto p
join	(
	select	v.codProduto ,
			v.dataVenda,
			sum(v.custo) as Custo,
			sum(v.quantidade) as Quantidade ,
			sum(v.valorVenda) as TotalVenda 
			from vendas v 
			group by v.codProduto,v.dataVenda--, v.custo
			having v.dataVenda between '2020-06-25' and '2020-07-04'
) v on v.codProduto = p.idProduto
group by v.dataVenda


--versao em uso 'Total Geral'
select	sum(v.TotalVenda) as 'Total de Vendas',
		sum(v.Custo) as 'Custo total',
		sum(v.TotalVenda - v.Custo) as 'Lucro total'		
from	produto p
join	(
	select	v.codProduto ,
			v.dataVenda,
			sum(v.custo) as Custo,
			sum(v.quantidade) as Quantidade ,
			sum(v.valorVenda) as TotalVenda 
			from vendas v 
			group by v.codProduto,v.dataVenda--, v.custo
			having v.dataVenda between '2020-06-25' and '2020-07-04'
) v on v.codProduto = p.idProduto



--produtos mais vendidos
select 		v.codProduto as 'Código do Produto',
		p.nome as 'Nome',
		coalesce(sum(v.quantidade), 0) as 'Quantidade'
from 	vendas v
join 	produto p 
on 		v.codProduto = p.idProduto
where v.dataVenda between '2020/07/01' and '2020/07/30'
group by v.codProduto
order by Quantidade desc;


-- estoque
select 	p.idProduto, 
		p.nome,
		coalesce(c.QuantidadeComprada, 0),
		coalesce(v.QuantidadeVendida, 0),
		(coalesce(c.QuantidadeComprada, 0) - coalesce(v.QuantidadeVendida, 0)) as EmEstoque
from 	produto p
left join (
		select  codProduto,
				coalesce(sum(quantidade), 0) as QuantidadeComprada
        from 	compra
        group by codProduto
	) c   
on	p.idProduto = c.codProduto
left join (
		select 	codProduto,
				coalesce(sum(quantidade), 0) as QuantidadeVendida
        from  	vendas
        group by codProduto
	) v
on	v.codProduto = p.idProduto
group by p.nome, p.idProduto
order by p.nome;