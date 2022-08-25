Create View QtdCandidatoPorVaga as 
select v.VAINOME as Vaga,
        COUNT(c.CANID) as Quantidade,
        v.VAIID as CodVaga
from VAGA v 
INNER JOIN CANDIDATOVAGA cv on cv.VAIID = v.VAIID 
INNER JOIN CANDIDATO c on c.CANID = cv.CANID
group by v.VAINOME, v.VAIID

select * from QtdCandidatoPorVaga