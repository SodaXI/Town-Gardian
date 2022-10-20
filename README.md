# Town-Gardian
Implement : PlayerMovement, Item_Setting
게임 명 : Town Gardian (임시)
개발 환경 : unity3d
진행 상황 : https://github.com/SodaXI/Town-Gardian
게임 장르 : 로그라이크 rpg -3d
시점 : 3인칭

싱글턴 패턴으로 구현 (player obj)

enemy type 
- boss 
	type D -> 현재 3가지 패턴을 가진 보스 몹
			ㄴ 유도 미사일
			ㄴ 플레이어 위치로 점프
			ㄴ 거대한 용암(구체) 굴리기 
- normal
	type A 기본 근접형
	type B 돌진형
	type C 원거리 공격형 
		-> map type에 따라 새로운 타입 

MAP TYPE 

1. 기본 도시 (수정 중)
ㄴ제작이후 플레이해 보니 맵의 크기가 필요 이상으로 커 스테이지가 증가함에 따라 이동할 수 있는 범위 확장

2. 파괴된 도시 (진행 중)
ㄴ 3d게임인 만큼 y축 방향으로 새로운 지형을 만들어 이동할 수 있도록 만듦

3. 중력에 영향을 받은 도시 (계획 중)
ㄴ 특정 위치에 도달하면 맵이 x, z축 방향으로 90도 회전하는 큐브 형태의 맵 생각 중

-> 포켓몬스터의 체육관 수준 정도의 기믹을 사용해여 맵에 효과를 줌

WEAPON TYPE
1. 기본 근접 망치
2. 단발형 원거리 무기
3. 연사형 원거리 무기
4. 복합형 근원거리 무기
5. 수류탄
+ 추가 계획
플레이어를 따라다니는 자동 공격형 드론/팻 시스템 
ㄴ 4번과 같은 방식으로 강화 고려


1,2,3 번에 해당하는 무기는 적을 처치하거나 상점에서 같은 무기를 구입하는 방식으로 공격력 강화

4번 무기는 적을 처치하여 확률적으로 드롭되는 아이템을 획득하여 무기 강화

5. 상점에서 사거나 적을 처치하여 획득가능 상한선은 4개  / 공력력 강화는 불가
