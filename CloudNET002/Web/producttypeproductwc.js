gx.evt.autoSkip=!1;gx.define("producttypeproductwc",!0,function(n){var t,i;this.ServerClass="producttypeproductwc";this.PackageName="GeneXus.Programs";this.ServerFullClass="producttypeproductwc.aspx";this.setObjectType("web");this.setCmpContext(n);this.ReadonlyForm=!0;this.anyGridBaseTable=!0;this.hasEnterEvent=!1;this.skipOnEnter=!1;this.autoRefresh=!0;this.fullAjax=!0;this.supportAjaxEvents=!0;this.ajaxSecurityToken=!0;this.DSO="Phamarcy";this.SetStandaloneVars=function(){this.AV6ProductTypeCode=gx.fn.getIntegerValue("vPRODUCTTYPECODE",",")};this.e13092_client=function(){return this.executeServerEvent("ENTER",!0,arguments[0],!1,!1)};this.e14092_client=function(){return this.executeServerEvent("CANCEL",!0,arguments[0],!1,!1)};this.GXValidFnc=[];t=this.GXValidFnc;this.GXCtrlIds=[2,3,4,5,6,7,8,10,11,12,13,14,16,17,18,19,20,21,22,23,24];this.GXLastCtrlId=24;this.GridContainer=new gx.grid.grid(this,2,"WbpLvl2",15,"Grid","Grid","GridContainer",this.CmpContext,this.IsMasterPage,"producttypeproductwc",[],!1,1,!1,!0,0,!0,!1,!1,"",0,"px",0,"px","New row",!0,!1,!1,null,null,!1,"",!1,[1,1,1,1],!1,0,!0,!1);i=this.GridContainer;i.addSingleLineEdit(1,16,"PRODUCTCODE","Code","","ProductCode","int",0,"px",10,10,"end",null,[],1,"ProductCode",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(2,17,"PRODUCTNAME","Name","","ProductName","char",0,"px",50,50,"start",null,[],2,"ProductName",!0,0,!1,!1,"attribute-description",0,"column");i.addSingleLineEdit(3,18,"PRODUCTPRICE","Price","","ProductPrice","decimal",0,"px",9,9,"end",null,[],3,"ProductPrice",!0,2,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addSingleLineEdit(4,19,"PRODUCTSTOCK","Stock","","ProductStock","int",0,"px",4,4,"end",null,[],4,"ProductStock",!0,0,!1,!1,"Attribute",0,"column WWOptionalColumn");i.addBitmap(7,"PRODUCTPHOTO",20,0,"px",17,"px",null,"","Photo","ImageAttribute","column WWOptionalColumn");this.GridContainer.emptyText="";this.setGrid(i);t[2]={id:2,fld:"",grid:0};t[3]={id:3,fld:"MAINTABLE",grid:0};t[4]={id:4,fld:"",grid:0};t[5]={id:5,fld:"GRIDCELL",grid:0};t[6]={id:6,fld:"GRIDTABLE",grid:0};t[7]={id:7,fld:"",grid:0};t[8]={id:8,fld:"",grid:0};t[10]={id:10,fld:"",grid:0};t[11]={id:11,fld:"",grid:0};t[12]={id:12,fld:"GRIDCONTAINER",grid:0};t[13]={id:13,fld:"",grid:0};t[14]={id:14,fld:"",grid:0};t[16]={id:16,lvl:2,type:"int",len:10,dec:0,sign:!1,pic:"ZZZZZZZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTCODE",fmt:0,gxz:"Z1ProductCode",gxold:"O1ProductCode",gxvar:"A1ProductCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A1ProductCode=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z1ProductCode=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(15),gx.O.A1ProductCode,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A1ProductCode=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTCODE",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[17]={id:17,lvl:2,type:"char",len:50,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTNAME",fmt:0,gxz:"Z2ProductName",gxold:"O2ProductName",gxvar:"A2ProductName",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",autoCorrect:"1",v2v:function(n){n!==undefined&&(gx.O.A2ProductName=n)},v2z:function(n){n!==undefined&&(gx.O.Z2ProductName=n)},v2c:function(n){gx.fn.setGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15),gx.O.A2ProductName,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A2ProductName=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTNAME",n||gx.fn.currentGridRowImpl(15))},nac:gx.falseFn};t[18]={id:18,lvl:2,type:"decimal",len:9,dec:2,sign:!1,pic:"ZZZZZ9.99",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPRICE",fmt:0,gxz:"Z3ProductPrice",gxold:"O3ProductPrice",gxvar:"A3ProductPrice",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A3ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2z:function(n){n!==undefined&&(gx.O.Z3ProductPrice=gx.fn.toDecimalValue(n,",","."))},v2c:function(n){gx.fn.setGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(15),gx.O.A3ProductPrice,2,".");typeof this.dom_hdl=="function"&&this.dom_hdl.call(gx.O)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A3ProductPrice=this.val(n))},val:function(n){return gx.fn.getGridDecimalValue("PRODUCTPRICE",n||gx.fn.currentGridRowImpl(15),",",".")},nac:gx.falseFn};t[19]={id:19,lvl:2,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTSTOCK",fmt:0,gxz:"Z4ProductStock",gxold:"O4ProductStock",gxvar:"A4ProductStock",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A4ProductStock=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z4ProductStock=gx.num.intval(n))},v2c:function(n){gx.fn.setGridControlValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(15),gx.O.A4ProductStock,0)},c2v:function(n){this.val(n)!==undefined&&(gx.O.A4ProductStock=gx.num.intval(this.val(n)))},val:function(n){return gx.fn.getGridIntegerValue("PRODUCTSTOCK",n||gx.fn.currentGridRowImpl(15),",")},nac:gx.falseFn};t[20]={id:20,lvl:2,type:"bits",len:1024,dec:0,sign:!1,ro:1,isacc:0,grid:15,gxgrid:this.GridContainer,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTPHOTO",fmt:0,gxz:"Z7ProductPhoto",gxold:"O7ProductPhoto",gxvar:"A7ProductPhoto",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",inputType:"text",v2v:function(n){n!==undefined&&(gx.O.A7ProductPhoto=n)},v2z:function(n){n!==undefined&&(gx.O.Z7ProductPhoto=n)},v2c:function(n){gx.fn.setGridMultimediaValue("PRODUCTPHOTO",n||gx.fn.currentGridRowImpl(15),gx.O.A7ProductPhoto,gx.O.A40000ProductPhoto_GXI)},c2v:function(n){gx.O.A40000ProductPhoto_GXI=this.val_GXI();this.val(n)!==undefined&&(gx.O.A7ProductPhoto=this.val(n))},val:function(n){return gx.fn.getGridControlValue("PRODUCTPHOTO",n||gx.fn.currentGridRowImpl(15))},val_GXI:function(n){return gx.fn.getGridControlValue("PRODUCTPHOTO_GXI",n||gx.fn.currentGridRowImpl(15))},gxvar_GXI:"A40000ProductPhoto_GXI",nac:gx.falseFn};t[21]={id:21,fld:"",grid:0};t[22]={id:22,fld:"",grid:0};t[23]={id:23,fld:"",grid:0};t[24]={id:24,lvl:0,type:"int",len:4,dec:0,sign:!1,pic:"ZZZ9",ro:1,grid:0,gxgrid:null,fnc:null,isvalid:null,evt_cvc:null,evt_cvcing:null,rgrid:[],fld:"PRODUCTTYPECODE",fmt:0,gxz:"Z5ProductTypeCode",gxold:"O5ProductTypeCode",gxvar:"A5ProductTypeCode",ucs:[],op:[],ip:[],nacdep:[],ctrltype:"edit",v2v:function(n){n!==undefined&&(gx.O.A5ProductTypeCode=gx.num.intval(n))},v2z:function(n){n!==undefined&&(gx.O.Z5ProductTypeCode=gx.num.intval(n))},v2c:function(){gx.fn.setControlValue("PRODUCTTYPECODE",gx.O.A5ProductTypeCode,0)},c2v:function(){this.val()!==undefined&&(gx.O.A5ProductTypeCode=gx.num.intval(this.val()))},val:function(){return gx.fn.getIntegerValue("PRODUCTTYPECODE",",")},nac:gx.falseFn};this.Z1ProductCode=0;this.O1ProductCode=0;this.Z2ProductName="";this.O2ProductName="";this.Z3ProductPrice=0;this.O3ProductPrice=0;this.Z4ProductStock=0;this.O4ProductStock=0;this.Z7ProductPhoto="";this.O7ProductPhoto="";this.A5ProductTypeCode=0;this.Z5ProductTypeCode=0;this.O5ProductTypeCode=0;this.A5ProductTypeCode=0;this.A40000ProductPhoto_GXI="";this.AV6ProductTypeCode=0;this.A1ProductCode=0;this.A2ProductName="";this.A3ProductPrice=0;this.A4ProductStock=0;this.A7ProductPhoto="";this.Events={e13092_client:["ENTER",!0],e14092_client:["CANCEL",!0]};this.EvtParms.REFRESH=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductTypeCode",fld:"vPRODUCTTYPECODE",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms["GRID.LOAD"]=[[],[]];this.EvtParms.ENTER=[[],[]];this.EvtParms.GRID_FIRSTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductTypeCode",fld:"vPRODUCTTYPECODE",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_PREVPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductTypeCode",fld:"vPRODUCTTYPECODE",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_NEXTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductTypeCode",fld:"vPRODUCTTYPECODE",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.EvtParms.GRID_LASTPAGE=[[{av:"GRID_nFirstRecordOnPage"},{av:"GRID_nEOF"},{ctrl:"GRID",prop:"Rows"},{av:"AV6ProductTypeCode",fld:"vPRODUCTTYPECODE",pic:"ZZZ9"},{av:"sPrefix"}],[]];this.setVCMap("AV6ProductTypeCode","vPRODUCTTYPECODE",0,"int",4,0);this.setVCMap("AV6ProductTypeCode","vPRODUCTTYPECODE",0,"int",4,0);this.setVCMap("AV6ProductTypeCode","vPRODUCTTYPECODE",0,"int",4,0);i.addRefreshingParm({rfrProp:"Rows",gxGrid:"Grid"});i.addRefreshingVar({rfrVar:"AV6ProductTypeCode"});i.addRefreshingParm({rfrVar:"AV6ProductTypeCode"});this.Initialize()})