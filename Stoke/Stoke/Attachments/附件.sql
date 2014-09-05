--DELETE FROM dsoc_flow_step WHERE flow_id = '15' AND step_id = '4'

INSERT INTO dsoc_flow_step(step_name, step_remark, flow_rule, flow_id,
	step_id, step_next)
VALUES('×Ü¾­Àí¿¼ÆÀ', '0', NULL, '15', '4', '1;2;3;-1')

SELECT step_name, step_remark, flow_rule, flow_id,
	step_id, step_next
FROM dsoc_flow_step
WHERE flow_id = '15'
ORDER BY step_id