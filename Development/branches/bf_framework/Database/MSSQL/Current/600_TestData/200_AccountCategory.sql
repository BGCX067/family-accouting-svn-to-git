exec cspd_CreateAccountCategory null, N'资产类', '1', 1
exec cspd_CreateAccountCategory null, N'负债类', '2', 2
exec cspd_CreateAccountCategory null, N'所有者权益类', '3', 2
exec cspd_CreateAccountCategory null, N'成本类', '4', 1
exec cspd_CreateAccountCategory null, N'损益类', '5'

exec cspd_CreateAccountCategory '1', N'银行存款', '1002'


exec cspd_CreateAccountCategory '2', N'短期借款', '2101'
exec cspd_CreateAccountCategory '2101', N'信用卡欠款', '210101'

exec cspd_CreateAccountCategory '5', N'主营业务收入', '5101', 2
exec cspd_CreateAccountCategory '5', N'营业外支出', '5601', 1

