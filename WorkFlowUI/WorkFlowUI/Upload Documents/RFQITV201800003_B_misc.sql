select MtlDescription,
						Cost,0 IsDefault,TypeCode,
						Quantity,'' UOM,IsAdded,CostType,GroupCode,Subcode,UOM as UOMType
					from WBSElementMisc 
					where TypeCode = '1' and MtlDescription not in (select misc.mtldescription from
										V_PCESCOSTDEV_miscellaneous as misc)  and wbselement = 'SGQ121-Main'
										
										SELECT     
			Misc.MtlDescription, 
		    case isnull(VMisc.Cost,0) when 0 then isnull(Misc.Cost,0)   else isnull(VMisc.Cost,0)  end cost , 
			Misc.IsDefault, 
			Misc.TypeCode, 
			isnull(VMisc.Quantity,0) Quantity, 
			Misc.UOM,
			isnull(VMisc.IsAdded,0),
			Misc.CostType,	
			Misc.GroupCode,
			Misc.SubCode,
			case when Misc.UOM=1 then 'Per Equipment' when Misc.UOM=3 then 'Common' end UOMType
			FROM         
			V_PCESCOSTDEV_Miscellaneous Misc 
			--INNER JOIN V_PCESCOSTDEV_Miscellaneous_AssignModel MAM ON Misc.MtlDescription = MAM.Mtl_Description 
			LEFT OUTER JOIN WBSElementMisc VMisc 
			ON Misc.MtlDescription = VMisc.MtlDescription and WBSElement = 'SGQ121-Main' WHERE (Misc.EquipmentCode = 4 ) 
			-- AND (MAM.ModelType = 'REXIA' ) 
			AND (Misc.TypeCode = '1')