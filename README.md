 # 🐉WUXIA SURVIVOR

>2D 무협 로그라이크 생존 게임
>Vampire Survivors에서 영감을 받아 제작된 탑다운 슈팅

![image](https://github.com/user-attachments/assets/58ed704f-ae0b-4842-95c1-c86a1ff29c07)


# 🚀0. Bulid (빌드 배포)

>👉 빌드 파일
>
>WuxiaSurvivor은 [Unity Play](https://play.unity.com/en/games/1a471d47-d832-4a0e-b54b-e22447b378d0/wuxia-survivor)에서 설치없이 플레이 가능합니다!

# 🎮1. Project Overview (프로젝트 개요)
| 항목 | 내용 |
|------|------|
| 프로젝트 이름| WUXIA SURVIVOR(무협 서바이벌) |
| 레퍼런스 게임 | 	Vampire Survivors |
| 게임 설명 | 2D 탑다운 로그라이크식 슈팅 게임 |
| 제작 기간 | 2025.3.27~2025.4.02(약 6일)|

# 👥2. Team Members (팀원 및 팀 소개)

| 한재민 | 송석호 | 이지영 | 김혜지 |
|:------|------|------|------|
| Programmer/PL | Programmer | Programmer | Programmer |
| [GitHub](https://github.com/kaffu0424) | [GitHub](https://github.com/SpartaCodingClub) | [GitHub](https://github.com/LeeJiyoung0511) | [GitHub](https://github.com/hgkim0728) |

# 🌟3. Key Features (주요 기능)

>👉 주요 기능 발표 자료 (PPT)


# 🛠️4. Tasks & Responsibilities (작업 및 역할 분담)

| 이름 | 역할 | 
|-----------------|-----------------|
| 한재민   | <ul><li>UI</li><li>이펙트</li><li>음악</li></ul>     |
| 송석호   | <ul><li>플레이어</li><li>몬스터</li></ul>      |
| 이지영   | <ul><li>맵</li><li>아이템</li><li>스킬 보조</li></ul> |
| 김혜지   | <ul><li>스킬</li></ul>     |


# 💻5. Technology Stack (기술 스택)
## 5.1 Language
|  |  |
|-----------------|-----------------|
| C#  | <img src="https://github.com/user-attachments/assets/4f255484-94a2-49dd-8648-2d8c794bcc54" alt="C#" width="100">
## 5.4 Cooperation
|  |  |
|-----------------|-----------------|
| Git    |  <img src="https://github.com/user-attachments/assets/483abc38-ed4d-487c-b43a-3963b33430e6" alt="git" width="100">    |
| Notion    |  <img src="https://github.com/user-attachments/assets/34141eb9-deca-416a-a83f-ff9543cc2f9a" alt="Notion" width="100">    |

# 🔁6. Development Workflow (개발 워크플로우)
<details>
<summary>브랜치 전략</summary>
 <br/>
 
> 우리 팀은 **Git Flow 전략**을 기반으로 다음과 같은 브랜치를 사용합니다.

### 🏷 Main Branch
- 항상 **배포 가능한 안정 상태의 코드**를 유지합니다.
- 모든 **배포는 이 브랜치**에서 이루어집니다.

### 🛠 Dev Branch
- 기능 개발이 완료된 브랜치는 이곳으로 **머지**됩니다.
- 중간 통합 테스트 및 안정성 확보를 위한 브랜치입니다.

### 🌱 Feature Branch (`Feature/이름-기능명`)
- 팀원 개별 개발 브랜치입니다.

</details>
<br/>

# 🧾7. Coding Convention (코드 컨벤션)
<details>
<summary>명명 규칙</summary>
 <br>
 
| 항목         | 스타일                         | 예시                          |
|--------------|--------------------------------|-------------------------------|
| **변수**     | - `private`, `protected` → 카멜케이스<br> - `public` → 파스칼케이스 | `playerHealth`, `enemySpeed`<br>`PlayerCount`, `MoveSpeed` |
| **프로퍼티** | 파스칼케이스                   | `IsActive`, `MoveSpeed`       |
| **메서드**   | 파스칼케이스 + XML 주석        | `MovePlayer()`, `Attack()`    |
| **클래스**   | 파스칼케이스                   | `PlayerController`, `EnemyAI` |
| **인터페이스** | `I` 접두사 + 파스칼케이스    | `IInteractable`, `IDamageable`|
| **열거형 (Enum)** | 파스칼케이스<br>각 항목은 첫글자만 대문자 | `GameState`, `MainMenu`<br>`Paused`, `Running` |
| **매개변수** | 소문자 카멜케이스              | `targetPosition`, `deltaTime` |
| **상수**     | 대문자 + 언더스코어            | `MAX_HEALTH`, `GRAVITY_FORCE` |

</details>
<br/>

# 📌8. Commit Convention (커밋 컨벤션)
<details>
<summary>기본 구조</summary>
 <br>
 
| 태그         | 설명                          | 예시                              |
|--------------|-------------------------------|-----------------------------------|
| `Feat`       | 새로운 기능 추가               | `[Feat] 캐릭터 점프 기능 추가`     |
| `Fix`        | 버그 수정                      | `[Fix] 공격 판정 오류 수정`        |
| `Comment`    | 주석 추가 또는 수정            | `[Comment]: 중요 로직 설명 주석 추가` |
| `Style`      | 코드 포맷팅, 네이밍 변경 등   | `[Style]: {} 위치 수정 및 변수명 변경` |
| `Refactor`   | 리팩토링 (기능 변경 없음)      | `[Refactor]: Update 메서드 구조 변경` |

</details>
<br/>
