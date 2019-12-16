set QUOTED_IDENTIFIER on
set ANSI_PADDING on

/*=================================================*/
/*       Drop database element                     */
/*=================================================*/

/*=============Table================*/

if object_id(N'[Safor_VW_ECNAlter]', N'u') is not null
begin
    exec p_DropForeignKey @TableName='[Safor_VW_ECNAlter]',@IsChildTable=0
    drop table [Safor_VW_ECNAlter]
end
go

if object_id(N'[Safor_VW_ECNAlterMOInfo]', N'u') is not null
begin
    exec p_DropForeignKey @TableName='[Safor_VW_ECNAlterMOInfo]',@IsChildTable=0
    drop table [Safor_VW_ECNAlterMOInfo]
end
go

if object_id(N'[Safor_VW_ECNInfo]', N'u') is not null
begin
    exec p_DropForeignKey @TableName='[Safor_VW_ECNInfo]',@IsChildTable=0
    drop table [Safor_VW_ECNInfo]
end
go

/*=================================================*/
/*       Create database element                   */
/*=================================================*/

/*=============Table================*/

create table [Safor_VW_ECNAlter]
(
    [ID] bigint not null,
    [CreatedOn] datetime null,
    [CreatedBy] nvarchar(50) null,
    [ModifiedOn] datetime null,
    [ModifiedBy] nvarchar(50) null,
    [SysVersion] bigint null,
    [ECNDocNo] nvarchar(50) null,
    [ItemMasterCode] nvarchar(50) null,
    [BOMVersionCode] nvarchar(50) null,
    [BOMType] nvarchar(50) null,
    [PreItemCode] nvarchar(50) null,
    [PreItemVersionCode] nvarchar(50) null,
    [PreIssueUomCode] nvarchar(50) null,
    [PreUsageQty] decimal(24, 9) null,
    [PreScrap] decimal(24, 9) null,
    [PreParentQty] decimal(24, 9) null,
    [ECNAction] nvarchar(50) null,
    [PostItemCode] nvarchar(50) null,
    [PostItemVersionCode] nvarchar(50) null,
    [PostIssueUomCode] nvarchar(50) null,
    [PostUsageQty] decimal(24, 9) null,
    [PostScrap] decimal(24, 9) null,
    [PostParentQty] decimal(24, 9) null,
    [ECNInfo] bigint null
)
go
exec p_CreateCustomType 'Safor_VW_ECNAlter'
go

create table [Safor_VW_ECNAlterMOInfo]
(
    [ID] bigint not null,
    [CreatedOn] datetime null,
    [CreatedBy] nvarchar(50) null,
    [ModifiedOn] datetime null,
    [ModifiedBy] nvarchar(50) null,
    [SysVersion] bigint null,
    [ECNAlter] bigint null,
    [IsAlter] nvarchar(50) null,
    [OrgCode] nvarchar(50) null,
    [MONo] nvarchar(50) null,
    [MOQty] decimal(24, 9) null,
    [PrePerUsageQty] decimal(24, 9) null,
    [PreUsageQty] decimal(24, 9) null,
    [DiffPerUsageQty] decimal(24, 9) null,
    [DiffUsageQty] decimal(24, 9) null,
    [PostPerUsageQty] decimal(24, 9) null,
    [PostUsageQty] decimal(24, 9) null,
    [MOTotalRcvQty] decimal(24, 9) null,
    [IssuedQty] decimal(24, 9) null,
    [PickListDocLineNo] int null,
    [IsFromPhantomExpanding] bit null
)
go
exec p_CreateCustomType 'Safor_VW_ECNAlterMOInfo'
go

create table [Safor_VW_ECNInfo]
(
    [ID] bigint not null,
    [CreatedOn] datetime null,
    [CreatedBy] nvarchar(50) null,
    [ModifiedOn] datetime null,
    [ModifiedBy] nvarchar(50) null,
    [SysVersion] bigint null,
    [ECNDocNo] nvarchar(50) null
)
go
exec p_CreateCustomType 'Safor_VW_ECNInfo'
go

/*=============PK================*/

alter table [Safor_VW_ECNAlter]
    add constraint pk_Safor_VW_ECNAlter
    primary key clustered
    ([ID] asc)
go

alter table [Safor_VW_ECNAlterMOInfo]
    add constraint pk_Safor_VW_ECNAlterMOInfo
    primary key clustered
    ([ID] asc)
go

alter table [Safor_VW_ECNInfo]
    add constraint pk_Safor_VW_ECNInfo
    primary key clustered
    ([ID] asc)
go

/*=============Default================*/

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [cd8507c6-380e-4d4a-83ba-00b47585a255_Default]
    default 0 for [SysVersion]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [f850f0bf-1233-4d0c-bad1-2559e112186e_Default]
    default 0 for [PreUsageQty]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [3857ba2b-be0c-4de3-bffa-ed32c14436cd_Default]
    default 0 for [PreScrap]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [48a63ef6-4bb1-4412-aff5-0f9410fbd021_Default]
    default 0 for [PreParentQty]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [b436cbe5-b615-4d7f-a5d4-d69472bf2bc0_Default]
    default 0 for [PostUsageQty]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [55971697-f1cf-4399-8937-d198a4706927_Default]
    default 0 for [PostScrap]
go

alter table [Safor_VW_ECNAlter]
    with check
    add constraint [fcbe69f2-a2f7-4574-9771-ad98aa90d809_Default]
    default 0 for [PostParentQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [5df2caeb-c2be-4d81-b3f5-6224f3727c03_Default]
    default 0 for [SysVersion]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [8ea90238-8cd4-451d-8eb3-fb43f05db997_Default]
    default 0 for [MOQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [e51b83bf-9506-4c49-bd4c-cd448ef8e7f1_Default]
    default 0 for [PrePerUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [325adc7f-fbb8-4b15-b572-eef70ffdf5c2_Default]
    default 0 for [PreUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [51460830-8419-4c38-aa3c-90ded911be3d_Default]
    default 0 for [DiffPerUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [c2ae0087-fa00-4a0c-8429-ad89d78a7255_Default]
    default 0 for [DiffUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [fc1415a6-c7f9-478a-a49c-f488f50eb0e3_Default]
    default 0 for [PostPerUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [aec8d159-39c2-4cb0-97b2-4c8b0d0215f7_Default]
    default 0 for [PostUsageQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [1bb3c7d6-724b-41d8-8cdc-e3ca079d864b_Default]
    default 0 for [MOTotalRcvQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [95e3f786-ad4a-4b4d-99a8-3b0da24e2f9b_Default]
    default 0 for [IssuedQty]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [96c1ac20-cfcf-42e3-ba89-6e456ec43226_Default]
    default 0 for [PickListDocLineNo]
go

alter table [Safor_VW_ECNAlterMOInfo]
    with check
    add constraint [6442d849-f681-48f4-9b92-67cf413d926c_Default]
    default 0 for [IsFromPhantomExpanding]
go

alter table [Safor_VW_ECNInfo]
    with check
    add constraint [35b50db9-6a28-45e9-b079-9ce8ab8f6e81_Default]
    default 0 for [SysVersion]
go

/*=============TableAllCheck================*/

ALTER TABLE [Safor_VW_ECNAlter] WITH CHECK NOCHECK CONSTRAINT ALL 
ALTER TABLE [Safor_VW_ECNAlterMOInfo] WITH CHECK NOCHECK CONSTRAINT ALL 
ALTER TABLE [Safor_VW_ECNInfo] WITH CHECK NOCHECK CONSTRAINT ALL 

