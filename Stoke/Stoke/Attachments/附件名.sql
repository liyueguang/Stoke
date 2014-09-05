--DELETE FROM dsoc_flow_style_description WHERE style_id = '15' --AND field_name = 'q'

INSERT INTO dsoc_flow_style_description(style_id, field_name)
	VALUES('15', 'i1')

SELECT *
FROM dsoc_flow_style_description
WHERE style_id = '15'